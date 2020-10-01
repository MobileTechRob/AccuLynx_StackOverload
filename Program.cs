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

            StackExchange.StacMan.StacManClient stackAppClient = new StackExchange.StacMan.StacManClient("IWxKGhjr9yw)JT7GHEQGaA((","2.1");

            DateTime startDate = DateTime.Now.AddDays(-1);
            DateTime endDate =  DateTime.Now;

            //DateTime startDate = DateTime.Parse("2017-01-01 00:00:00");
            //DateTime endDate = DateTime.Parse("2020-09-27 23:59:59");

            Task<StackExchange.StacMan.StacManResponse<Question>> mainQueryQuestiontask = stackAppClient.Search.GetMatchesAdvanced("stackoverflow.com", "withbody",null,null,startDate, endDate,null,null,null,null,null,null,null,true,2);
            
            StacManResponse<Question> listOfQuestions = mainQueryQuestiontask.Result;

            List<int> listOfQuestionIds = new List<int>();

            foreach (Question q in listOfQuestions.Data.Items)
            {
                listOfQuestionIds.Add(q.QuestionId);
            }

            // now we have a list of questions with an accepted answer and more than one answer.
            // for each question
            // get the question title and question body  .. this will be one row.
                                                                  
            // get the question title and bodies and accepted answer id associated with list of question ids.
            Task<StackExchange.StacMan.StacManResponse<Question>> questionstask = stackAppClient.Questions.GetByIds("stackoverflow.com", listOfQuestionIds, "withbody");
            StackExchange.StacMan.StacManResponse<Question> listOfQuestionInfo = questionstask.Result;





            Task<StackExchange.StacMan.StacManResponse<Answer>> answerstask = stackAppClient.Questions.GetAnswers("stackoverflow.com", listOfQuestionIds, "withbody");
            StackExchange.StacMan.StacManResponse<Answer> listOfAnswerInfo = answerstask.Result;



            List<int> answers = new List<int>();
            List<int> questionsWithAcceptedanswer = new List<int>();

            Dictionary<int, List<int>> allAnswersWithQuestions = new Dictionary<int, List<int>>();
            Dictionary<int, List<int>> allAnswersWithQuestionsFinalList = new Dictionary<int, List<int>>();

            //foreach (var answer in listOfAnswers.Data.Items)
            //{
            //    Console.WriteLine(" Quesiton Is " + answer.QuestionId.ToString() + " answer is " + answer.AnswerId.ToString());

            //    if (allAnswersWithQuestions.ContainsKey(answer.QuestionId) == false)
            //    {
            //        allAnswersWithQuestions.Add(answer.QuestionId, new List<int>());
            //    }

            //    allAnswersWithQuestions[answer.QuestionId].Add(answer.AnswerId);

            //    if (answer.IsAccepted == true)
            //    {                   
            //        if (questionsWithAcceptedanswer.Contains(answer.QuestionId) == false)
            //        {
            //            questionsWithAcceptedanswer.Add(answer.QuestionId);
            //            Console.WriteLine(" Quesiton With accepted answer : Question is " + answer.QuestionId.ToString() + " accepted answer is " + answer.AnswerId.ToString());
            //        }
            //    }

            //    //Console.WriteLine(answer.Title);
            //    //Console.WriteLine(answer.Comments);
            //    //Console.WriteLine(answer.QuestionId);
            //}

            //if (questionsWithAcceptedanswer.Count > 0)
            //{
            //Console.WriteLine("There are questions with an accepted answer");

            // loop throught questions with accepted answer;
            //  find that question in the first list and copy it to the final list;

            //foreach (int question in allAnswersWithQuestions.Keys)
            //{
            //    allAnswersWithQuestionsFinalList.Add(question, allAnswersWithQuestions[question]);
            //    Console.WriteLine("Question with accepted answer to final list is " + question.ToString());
                                                          

            //    List<int> tempQuestion = new List<int>();
            //    tempQuestion.Add(question);

            //    Task<StackExchange.StacMan.StacManResponse<Question>> questiontask = stackAppClient.Questions.GetByIds("stackoverflow.com", tempQuestion, "withbody");
            //    StackExchange.StacMan.StacManResponse<Question> returnedQuestion = questiontask.Result;


            //    //int theanswers = returnedQuestion.Data.Items.Length;

            //    Question q2 = (Question)returnedQuestion.Data.Items[0];

            //    string questiontitle = q2.Title;

            //    //int? acceptedAnswerID = q2.AcceptedAnswerId;
            //    //int? numberAnswers = q2.AnswerCount;

            //    List<int> answerList = new List<int>();


            //    //for (int index = 1; index <= numberAnswers; index++)
            //    //{
            //      //  int? answer = q2.Answers[index - 1].AnswerId;
            //    answerList.Add(allAnswersWithQuestions[question][0]);
            //    //                  }

            //    // from this build the IEnumberable<int> and then then  
            //    Task<StackExchange.StacMan.StacManResponse<Answer>> answertask = stackAppClient.Answers.GetByIds("stackoverflow.com", answerList, "withbody");

            //    StackExchange.StacMan.StacManResponse<Answer> returnedAnswer = answertask.Result;

            //    string answerBody = returnedAnswer.Data.Items[0].Body;


            //}

            //IEnumerable<int> queryQuestionsWithAcceptedAnswer = 
            //from answer in allAnswersWithQuestions.Keys
            //from question in questionsWithAcceptedanswer where questionsWithAcceptedanswer.Contains(answer) select answer;

            //IEnumerator<int> iter = queryQuestionsWithAcceptedAnswer.GetEnumerator();

            //while (true)
            //{
            //  if (iter.MoveNext() == true)
            //Console.WriteLine("Question with accepted answer from main collection  is " + iter.Current);
            //}
            //}                                                                                              
            //var questions = stackAppClient.Questions.GetByIds("stackoverflow", answers).Result;
            //StringBuilder str = new StringBuilder();

            //foreach (var question in questions.Data.Items)
            //{
            //    str.Append(question.Title);
            //    str.Append("  ");
            //    str.AppendLine(question.Body);
            //    string line = str.ToString();

            //    Console.WriteLine(line);                
            //}                                                          
        }
    }
}

/*

get all answers back
         each answerid has a question id


         answerid 1   question id
         answerid 2   question id




      Dictionary<string, list<string>) 
                 question     answers

      





    goal is to list all the questions with more than one answer and one accepted answers

    */
    
