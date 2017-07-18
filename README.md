# Post-It-List
Open source productivity web app. A simple .NET Core implementation of a to-do-list with a javascript front end, all deployed on Azure.
* Simple adding, removing and editing tasks.
* Persistance - tasks saved in a database hosted on Azure.
* Functionality done with an API, so a mobile app could easily be developed.
* Future stretch goals for the product include API authorization, and syncing with Google.
Copyright (c) 2017 David Stamper, Ashton Hunger, Jonathan Jensen


## July 12th 2017 Week 3 Report:

The project has had its environment successfully created and it is able to run using Visual Studio. The start of API and Web app
was successfully created. The API supports adding a to-do item to a list of to-do items. The Web app, currently, has a home page, and a
second page that holds the list that a user creates. The Web app is able to add a list of to-do items without a page refresh and 
supports a button press that adds a item in the list. The model now has an id, completion status, and time to describe a task-list. 

The next focus point for week 4 is to get the API endpoints working with real data from the updated model. Currently the API only touches the key value. On the web side we're looking to do start working on more javascript with dummy data to implement our API interface, with actions such as edit and delete.


MIT License

Copyright (c) 2017 David Stamper, Ashton Hunger, Jonathan Jensen

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
