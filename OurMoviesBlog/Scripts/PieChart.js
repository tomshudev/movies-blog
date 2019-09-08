$(document).ready(function () {
        var svg = d3.select("svg"),
        width = +svg.attr("width"),
        height = +svg.attr("height"),
        radius = Math.min(width, height) / 2,
        g = svg.append("g").attr("transform", "translate(" + width / 2 + "," + height / 2 + ")");

    var color = d3.scaleOrdinal(["pink", "#98abc5", "lightgreen", "lightblue", "#6b486b", "coral", "#d0743c", "#ff8c00"]);

    var pie = d3.pie()
        .sort(null)
            .value(function (d) { return d.value; });

var path = d3.arc()
    .outerRadius(radius - 10)
    .innerRadius(0);

var label = d3.arc()
    .outerRadius(radius - 40)
    .innerRadius(radius - 40);

var genres = ['Comedy', 'Action', 'Animated', 'Horror', 'ScienceFiction', 'Drama', 'Historical'];

        d3.json("/Movies/IndexData", function (data) {
            var groupByGenre = {};

            data.forEach(function (d) {
        groupByGenre[d.Genre] = (groupByGenre[d.Genre] || 0) + 1;
    });

            var revisedData = Object.keys(groupByGenre).map(function (d) { return {value: groupByGenre[d], role: genres[d] } });

    var arc = g.selectAll(".arc")
        .data(pie(revisedData))
        .enter().append("g")
        .attr("class", "arc");

    arc.append("path")
        .attr("d", path)
                .attr("fill", function (d) { return color(d.index); });

arc.append("text")
                .attr("transform", function (d) { return "translate(" + label.centroid(d) + ")"; })
    .attr("dy", "0.35em")
                .text(function (d) { return d.data.role + " " + d.data.value });
})
})