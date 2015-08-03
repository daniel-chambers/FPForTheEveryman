var express = require('express');
var router = express.Router();

/* GET home page. */
router
  .get('/bad', function(req, res, next) {
    res.render('userSearchBad', {});
  })
  .get('/good', function(req, res, next) {
    res.render('userSearchGood', {});
  })
  .get('/api', function (req, res, next) {
    
    var results = [{name: req.query.q}];
    var timeout = 1000;
    
    if (req.query.q === "slow") {
      results = [
        {name: "all"}, 
        {name: "my"}, 
        {name: "sluggish"}, 
        {name: "results"}
      ].concat(results);
      timeout = 5000;
    }
    else if (req.query.q === "slow fast") {
      results = [
        {name: "such"}, 
        {name: "speed"}, 
        {name: "much"}, 
        {name: "results"}, 
        {name: "wow"}
      ].concat(results);
    }
    
    setTimeout(function() { 
      res
        .set("Cache-Control", "private, max-age=0, no-cache")
        .json(200, { i: req.query.i, results: results });
    }, timeout);
  });


module.exports = router;
