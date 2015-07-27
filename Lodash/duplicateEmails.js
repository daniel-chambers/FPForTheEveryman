var _ = require("lodash");

function getDuplicatedEmails(users)
{
	return _.chain(users)
	    .countBy(user => (user.email || "").toLowerCase().trim())
	    .pick((count, email) => count > 1 && email != "")
	    .map((count, email) => email)
	    .value();
}

var users = [
	{ email: "darth.vader@theempire.com", firstName: "Darth", surname: "Vader" },
	{ email: "skywalker@rebellion.com", firstName: "Luke", surname: "Skywalker" },
	{ email: "darth.vader@theempire.com", firstName: "Anakin", surname: "Skywalker" }
];

console.log(getDuplicatedEmails(users));