// https://medium.com/making-internets/why-using-chain-is-a-mistake-9bc1f80d51ba

var flow = require("lodash/fp/flow");
var first = require("lodash/fp/first");
var drop = require("lodash/fp/drop");
var take = require("lodash/fp/take");
var join = require("lodash/fp/join");
var last = require("lodash/fp/last");

function splitFullName(fullName) {
    var names = fullName
        .split(" ")
        .filter(function (n) { return n !== ""; });

    return {
        firstName: first(names) || null,
        middleName: flow(
            drop(1),
            take(names.length - 2),
            join(" ")
            )(names) || null,
        surname: names.length > 1
            ? last(names)
            : null
    }
}

console.log("Split Names v2")
console.log("--------------")
console.log(splitFullName(""));
console.log(splitFullName("Carlos"));
console.log(splitFullName("Carlos Norris"));
console.log(splitFullName("Carlos Ray Norris"));
console.log(splitFullName("Carlos Ray 'Chuck' Norris"));
console.log("--------------")

// -- Uncurried drop function ---
function myDropUncurried(count, arr) {
    return arr.slice(count); //Naive for demo simplicity
}

// --- Curried drop function ---
function myDrop(count) {
    return function (arr) {
        return arr.slice(count); //Naive for demo simplicity
    }
}

console.log("myDrop")
console.log("--------------")

var dropped = myDrop(1)([1,2,3])
console.log(dropped);