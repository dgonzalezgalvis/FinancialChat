# FinancialChat




# Set up environment:

1. Download current code.
2. Open it with a Visual Studio .NET 4.5 environment (Although solution was made with VS 2017, the projects were build with .NET 4.5 so VS 2015 should work).
3. Set up FinancialChat.WebApp as StartUp project.
3. This project works with RabbitMQ Server 3.7.7 to syncronize the bot, it is necessary to have the local service running in case you want to access the bot. 
Also, take into account that Erlang OTP 21 is a requirement to install the RabbitMQ Service.



# Install WebApp:

1. Publish FinancialChat.WebApp in your Azure, IIS or locally (files are already published in FinancialChat.WebApp\bin\Release\Publish).
2. Bring files to your local server in case they were locally published.
3. Add new project website.

OR

Open the code in VS2015/2017, set up FinancialChat.WebApp as StartUp project and run it with IIS Express.



# Run Bot

1. Go to FinancialChart.Bot\bin\Debug
2. Open console and execute FinancialChart.Bot.exe
