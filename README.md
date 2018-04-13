# WeatherApp ReadMe

This App was built as part a of "Mobile Applications Development 2" course in Software Development.
## The brief ##
Create a Universal Windows Project (UWP).
The UWP application should be well designed with a clear purpose in mind. Answer the question
“why will the user open this app for a second time?” as part of the design process. What makes your
app better than the others available offering the same function?
The application can be a game (UNITY is acceptable with C# scripting) or an interactive information
app. What the app does is up to you. You can have a single page app, or one with many pages – that
is a choice. 

I decided to create a weather app as it allowed me to use the users location to get there local weather. 
The app along with giving the user today's weather will also give them a 5 day forecast at the click of a button. 
The reason I think users will reuse this app is because the weather will always change. 
This app also uses longitude and latitude to get the local weather instead of the inaccuracy of using a city code. 
So that if the user is out in the woods or a remote location the weather will be more likely to be accurate to there place. 
![screenshot 2](https://user-images.githubusercontent.com/22493191/38758901-131846ae-3f6b-11e8-8337-5ddf6a0a7aa1.png)

The app will also display a five day weather forcast based on the useres location with the click of a button. 
![screenshot 5](https://user-images.githubusercontent.com/22493191/38759059-d6bc49b6-3f6b-11e8-8dea-e987b5c821c6.png)
## How the project works ##
The app was built with c# in uwp using visual studios 2017. The app calls an api from [openweathermap.org](http://openweathermap.org/api)
to get the weather forecast in a Json file. I then used   [Json2C#](http://json2csharp.com/) to create the cs file that reads in 
the json data. 
I submitted the app to the windows app store and it is currently under review. 
## Issues ##
When running the Windows App Certification on my local machiene it doesnt pass due to the image below
![visualstudiowindow](https://user-images.githubusercontent.com/22493191/38760749-86345cb8-3f75-11e8-982e-7359ed451fe0.png)
![results](https://user-images.githubusercontent.com/22493191/38760754-93a6f4dc-3f75-11e8-8897-1927e1ed6a31.png)
This may be caused by a spefic libraries that require particular versions of Windows but so far I have been unable to find the cause. 
![2018-04-13 23_54_19-windows app certification kit - test results](https://user-images.githubusercontent.com/22493191/38760806-0fa46966-3f76-11e8-915c-e28dfd7decec.png)

## Useful Links ##

[Tutorial: Use Grid and StackPanel to create a simple weather app](https://docs.microsoft.com/en-us/windows/uwp/design/layout/grid-tutorial)

[WeatherView – a universal Windows app sample written in C#](https://blogs.msdn.microsoft.com/johnkenn/2014/05/28/weatherview-a-universal-windows-app-sample-written-in-c/)

[Deserialize JSON from a file](https://www.newtonsoft.com/json/help/html/DeserializeWithJsonSerializerFromFile.htm)

[Get the user's location](https://docs.microsoft.com/en-us/windows/uwp/maps-and-location/get-location)

[openweathermap.org](http://openweathermap.org/api)

