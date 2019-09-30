# Functional Programming for the Everyman
This repository contains the presentation materials and sample code for the Functional Programming for the Everyman presentation. Here's the abstract:

> You’ve probably heard that “functional programming is the next big thing” and that modern imperative languages like C# and JavaScript are adopting features from functional programming. So how can you, as a developer living in a normal imperative code base, start taking advantage of functional programming from where you are now, without needing to throw yourself in the deep end and change languages?

> In this talk we’ll take a look at functional programming libraries that already exist in .NET and JavaScript, such as [LINQ][7]/[lodash][8] and [Rx/RxJS][9], and walk through practical examples of imperative code that could be written in a more functional style in order to produce more concise, readable and maintainable code.

> Once you get a taste of functional programming, you won’t want to go back. :)

Video: [NDC Sydney 2016](https://www.youtube.com/watch?v=V69C7HDTB3o)

To get the sample code up and running you will need:

* [LINQPad][1] - for the C# examples
* [NodeJS][2] - for the JavaScript examples
* [Visual Studio Code][3] (optional) - to browse the JavaScript code

To run the JavaScript examples, you will need to perform an `npm install` in the `Lodash` and `RxJs` directories in order to restore all the required [NPM][4], [Bower][5] and [TSD][6] files.

To start the webserver required for the `RxJs` examples, you can either F5 in VS Code, or run `node ./bin/www` from your console. The webserver will start at [http://localhost:3000/][11]. The webserver is done using [Express][12].


### Additional Reading
If you'd like to learn more about Rx, the [Introduction to Rx][10] website/book is a good (and older; but still relevant) first step.

[1]: https://www.linqpad.net/
[2]: https://nodejs.org/
[3]: https://code.visualstudio.com/
[4]: https://www.npmjs.com/
[5]: http://bower.io/
[6]: http://definitelytyped.org/tsd/
[7]: https://msdn.microsoft.com/en-us/library/bb397926.aspx
[8]: https://lodash.com/
[9]: http://reactivex.io/
[10]: http://www.introtorx.com/
[11]: http://localhost:3000/
[12]: http://expressjs.com/
