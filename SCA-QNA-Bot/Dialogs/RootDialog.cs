using System;
using System.Threading.Tasks;
using Microsoft.Bot.Builder.Dialogs;
using Microsoft.Bot.Connector;
using QnAMakerDialog;

namespace SCA_QNA_Bot.Dialogs
{
    [Serializable]
    [QnAMakerService("6efef4ee064b4afa9c18fb512f11609a", "710c9068-608b-4b0d-8aaf-90bdf52d2605")]
    public class RootDialog : QnAMakerDialog<Object>
    {
        public override async Task NoMatchHandler(IDialogContext context, string originalQueryText)
        {
            await context.PostAsync($"Sorry, I could not find an answer for '{originalQueryText}'. ");
            context.Wait(MessageReceived);
        }

        [QnAMakerResponseHandler(50)]
        public async Task LowScoreHandler(IDialogContext context, string originalQueryText, QnAMakerResult result)
        {
            await context.PostAsync($"I found an answer that might help...{result.Answer}.");
            context.Wait(MessageReceived);
        }
    }
}