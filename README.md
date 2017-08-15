# Post-It-List
Open source productivity web app. A simple .NET Core implementation of a to-do-list with a javascript front end, all deployed on Azure.
* Simple adding, removing and editing tasks.
* Persistance - tasks saved in a database hosted on Azure.
* Functionality done with an API, so a mobile app could easily be developed.
* Future stretch goals for the product include API authorization, and syncing with Google.

Copyright (c) 2017 David Stamper, Ashton Hunger, Jonathan Jensen


## How to Build/Run
For this project we are using Visual Studio as an environment for testing and running. It is recommended that Visual Studio is installed in order to make working on the project easier.

* Once Visual Studio is installed, git clone the repository in a directory of your choosing.
* To open the project, start Visual Studio, go to File -> Open, then navigate to your directory with the cloned repository and open the .sln file.
* To run the project, first right click PostitList.Web.
  * Go to Properties
  * Change the Environement variables so that Name is ASPNETCORE_ENVIRONMENT and Value is Development
  * Change the App URL to http://localhost:5000/
* Right click PostitList.API
  * Go to Properties
  * Change the Environement variables so that Name is ASPNETCORE_ENVIRONMENT and Value is Development
  * Change the App URL to http://localhost:5001/
* Right click PostitList.API
  * Click Debug -> Start new instance
* At the top of the page go to Debug -> Start Without Debugging

After following these instructions your browser should pop-up and you can navigate the PostitList website.


## How to Use PostitList

To use the deployed version of the project go to http://postitlist.com.

Once at the website you will be at a home page with 3 tabs: List, About, Contact. The List tab is where you can create your own to do list. When you first get to the page, there will be two example items to show what the list will look like. You can delete these by clicking the X button to the right of the items. To add something to the list, click Add at the bottom of the page. You can then type in a title of your choosing and an optional due date for the task. Once finished click Add to List. 

Once you have created your list, you can either add more items, edit your current items, or delete your current items. To edit your items click on the Edit button. Once the Edit button is selected you can type into the Title or Due Date field. You are also able to check or uncheck the Completed field. Once you are done editting your item, click the save button. Once the save button is selected you can no longer edit items. To remove an item, simply click the X button to the right of the item.


## July 12th 2017 Week 3 Report:

The project has had its environment successfully created and it is able to run using Visual Studio. The start of API and Web app
was successfully created. The API supports adding a to-do item to a list of to-do items. The Web app, currently, has a home page, and a
second page that holds the list that a user creates. The Web app is able to add a list of to-do items without a page refresh and 
supports a button press that adds a item in the list. The model now has an id, completion status, and time to describe a task-list. 

The next focus point for week 4 is to get the API endpoints working with real data from the updated model. Currently the API only touches the key value. On the web side we're looking to do start working on more javascript with dummy data to implement our API interface, with actions such as edit and delete.


## Contact Information

### Email
Jonathan Jensen: jojensen@pdx.edu
David Stamper: dstamper@pdx.edu


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
