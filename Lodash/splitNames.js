var _ = require("lodash");

function splitFullName(fullName) {
    var names = fullName
        .split(" ")
        .filter(function (n) { return n !== ""; });

    return {
        firstName: _.first(names) || null,
        middleName: _.chain(names)
            .drop(1)
            .take(names.length - 2)
            .join(" ")
            .value()
            || null,
        surname: names.length > 1
            ? _.last(names)
            : null
    }
}

console.log(splitFullName(""));
console.log(splitFullName("Carlos"));
console.log(splitFullName("Carlos Norris"));
console.log(splitFullName("Carlos Ray Norris"));
console.log(splitFullName("Carlos Ray 'Chuck' Norris"));