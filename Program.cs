using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange;
using StackExchange.StacMan;

namespace AccuLynx_StackOverload
{
    class Program
    {
        static void Main(string[] args)
        {

            StackExchange.StacMan.StacManClient stackAppClient = new StackExchange.StacMan.StacManClient("IWxKGhjr9yw)JT7GHEQGaA((");

            //DateTime startDate = DateTime.Now.AddMonths(-6);
            //DateTime endDate =  DateTime.Now;

            DateTime startDate = DateTime.Parse("2020-04-01");
            DateTime endDate = DateTime.Parse("2020-09-27");

            var listOfAnswers = stackAppClient.Answers.GetAll("stackoverflow",null,null,null,startDate,endDate,                                                                                                         
                                                    sort: StackExchange.StacMan.Answers.Sort.Creation,
                                                    order: Order.Desc).Result;

            List<int> answers = new List<int>();

            if (listOfAnswers.Data.Items.Length > 1)
            {
                Console.WriteLine(" Quesiton Is");

                foreach (var answer in listOfAnswers.Data.Items)
                {
                    ```

                    if (answer.IsAccepted == true)
                    {
                        answers.Add(answer.QuestionId);                        
                    }

                    Console.WriteLine(answer.Title);
                    Console.WriteLine(answer.Comments);
                    Console.WriteLine(answer.QuestionId);

                }
            }

            var questions = stackAppClient.Questions.GetByIds("stackoverflow", answers).Result;
            StringBuilder str = new StringBuilder();

            foreach (var question in questions.Data.Items)
            {
                str.Append(question.Title);
                str.Append("  ");
                str.AppendLine(question.Body);
                string line = str.ToString();

                Console.WriteLine(line);                
            }                                                  
        }
    }
}
