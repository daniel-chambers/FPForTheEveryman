var express = require('express');
var router = express.Router();

/* GET home page. */
var state = "Loading";

router
  .get('/', function(req, res, next) {
    res.render('serverPolling', {});
  })
  .get('/helper', function(req, res, next) {
    res.render('serverPollingHelper', {});
  })
  .get('/api', function (req, res, next) {
    var date = new Date();
    res.json(200, { serverTime: date, state: state });
  })
  .post("/api", function(req, res, next) {
    state = req.query.state;
    res.sendStatus(200);
  });


module.exports = router;
