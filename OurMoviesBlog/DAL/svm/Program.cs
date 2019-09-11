using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using DataAccess;
using libsvm;

namespace SVMTextClassifier
{
    class Program
    {
        private static Dictionary<int, string> _predictionDictionary = new Dictionary<int, string> { { 1, "NewMovies" }, { 2, "Celebs" }, { 3, "Reviews" }, { 4, "BehindTheScene" }, { 5, "NewsFlash" } };
        private static List<string> vocabulary;
        private static C_SVC model;
        //private const string dataFilePath = @"C:\devl\work\OurMoviesBlog\OurMoviesBlog\DAL\svm\Data.csv";
        private static string dataFilePath = HttpContext.Current.Server.MapPath("~/DAL/svm/");


        public static void Main()
        {
            // STEP 4: Read the data
            string dataFilePath = HttpContext.Current.Server.MapPath("~/DAL/svm/");
            var dataTable = DataTable.New.ReadCsv(dataFilePath + "Data.csv");
            List<string> x = dataTable.Rows.Select(row => row["Text"]).ToList();
            double[] y = dataTable.Rows.Select(row => double.Parse(row["Category"]))
                                       .ToArray();

            vocabulary = x.SelectMany(GetWords).Distinct().OrderBy(word => word).ToList();

            var problemBuilder = new TextClassificationProblemBuilder();
            var problem = problemBuilder.CreateProblem(x, y, vocabulary.ToList());

            // If you want you can save this problem with : 
            // ProblemHelper.WriteProblem(@"D:\MACHINE_LEARNING\SVM\Tutorial\sunnyData.problem", problem);
            // And then load it again using:
            // var problem = ProblemHelper.ReadProblem(@"D:\MACHINE_LEARNING\SVM\Tutorial\sunnyData.problem");

            const int C = 1;
            model = new C_SVC(problem, KernelHelper.LinearKernel(), C);

            var accuracy = model.GetCrossValidationAccuracy(10);
            Console.Clear();
            Console.WriteLine(new string('=', 50));
            Console.WriteLine("Accuracy of the model is {0:P}", accuracy);
            model.Export(string.Format(dataFilePath + "model_{0}_accuracy.model", accuracy));

            Console.WriteLine(new string('=', 50));
            Console.WriteLine("The model is trained. \r\nEnter a sentence to make a prediction. (ex: sunny rainy sunny)");
            Console.WriteLine(new string('=', 50));
        }

        public static string Predict(string userInput)
        {
            var newX = TextClassificationProblemBuilder.CreateNode(userInput, vocabulary);
            var predictedY = model.Predict(newX);

            Console.WriteLine("The prediction is {0}", _predictionDictionary[(int)predictedY]);
            return _predictionDictionary[(int)predictedY];
        }

        public static void AddPrediction(string userInput, int prediction)
        {
            string[] words = userInput.Split(' ');

            foreach (string w in words)
            {
                File.AppendAllText(dataFilePath + "Data.csv", Environment.NewLine + w + "," + prediction);
            }
        }

        private static IEnumerable<string> GetWords(string x)
        {
            return x.Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }
    }
}