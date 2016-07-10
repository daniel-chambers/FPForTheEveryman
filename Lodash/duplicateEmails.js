var _ = require("lodash/fp");

function getDuplicatedEmails(users)
{
	return _.flow(
	    _.countBy(user => user.email.toLowerCase().trim()),
	    _.pickBy((count, email) => count > 1),
	    _.keys
		)(users);
}

var users = [
	{ email: "darth.vader@theempire.com", firstName: "Darth", surname: "Vader" },
	{ email: "skywalker@rebellion.com", firstName: "Luke", surname: "Skywalker" },
	{ email: "darth.vader@theempire.com", firstName: "Anakin", surname: "Skywalker" }
];

console.log(getDuplicatedEmails(users));