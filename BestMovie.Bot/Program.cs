﻿using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using BestMovie.BLL.Services;
using BestMovie.Bot.View;
using BestMovie.Entities;
using BestMovie.Parser;
using BestMovie.Parser.Settings;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;

namespace BestMovie.Bot
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var botClient = new TelegramBotClient(Configuration.BotToken);

             using var cts = new CancellationTokenSource();
             // StartReceiving does not block the caller thread. Receiving is done on the ThreadPool.
             botClient.StartReceiving(
                 new DefaultUpdateHandler(Handlers.HandleUpdateAsync, Handlers.HandleErrorAsync),
                 cts.Token);
            
             Console.ReadLine();
             // Send cancellation request to stop bot
             cts.Cancel();
        }
    }
}
