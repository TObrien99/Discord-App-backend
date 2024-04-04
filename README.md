# Ingentive-Discord-App
An app composoed of React &amp; a .Net 8.0 API with a discord wrapper to effectively create a bot which can perform simples tasks and allows database visibility via its react-front end 

# Adding the Bot to your Discord Server
You can create your own bot and attach it to the functionality provided in this repository.

**NOTE: Skip to the alternative method below if you want to use the bot that I created they are both functionally the same, however this method requires you to configure the bot in the app yourself**
1. Head to the [discord developer portal](https://discord.com/developers) and sign in
2. When you are inside, go to the applications blade oon the left
3. Click "new application" on the top-right, name your application and create
4. Go to the 'Bot' blade on the left
5. Check each of the boxes on the following permissions: PRESENCE INTENT, SERVER MEMBERS INTENT, MESSAGE CONTENT INTENT. Save changes
6. Go to Oauth2 blade on the left
7. Click "URL Generator"
8. in the grid of options select "applications.commands and also select "bot"
9. In the newly appearing Bot Permissions table below check "Administrator"
10. At the very bottom of the page you will have a url generated. Paste this into your browser and sign in with you discord account and you will be promoted to add your bot to your server
11. Go back to the 'Bot' blade on the left, click "reset token" and copy this token into a notepad (you will need this to allow the discord .net application wrapper to use your bot


**Alternative Method**

If you want too simply add the bot to your server you can do by navigating to this URL: 

https://discord.com/oauth2/authorize?client_id=1222963469201182800&permissions=8&scope=bot+applications.commands

This will install the bot that I have created.


# Getting the App up and running:

1. Firstly grab the code and open up two instances of Visual Studio 2022
2. Navigate to both projects so you can see both the **frontend** and **backend** applications
3. In your first IDE navigate to the **backend** folder:
- Double click into the solution named DISCORD-API.sln
- Navigate to \Teddy-Ingentive-Discord-Bot\Program.cs - change line 17 to look like this:
  
string discordBotToken = "{YOUR_GENERATED_DISCORD_BOT_TOKEN}";
- Alternatively set up your token inside your Secrets vault see more info [here](https://learn.microsoft.com/en-us/aspnet/core/security/app-secrets?view=aspnetcore-8.0&tabs=windows)
- Right click the solution and click properties, set both projects to 'Start' under "multiple startup projects" apply and ok
- press F5 or click the green start arrow on the top of the screen
- You should then see two interfaces appear as well as a browser window open to https://localhost:7183/swagger/index.html
4. In your second IDE navigate to the **frontend** project:
- Open your terminal, if not already there, navigate to the following path within your terminal: **\Teddy-Ingentive\frontend\\>**
- Type in the terminal **npm install** to install package dependencies
- Then type **npm start**, this should start the react front end on https://localhost:3000/
   
