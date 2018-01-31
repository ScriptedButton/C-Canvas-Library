using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Newtonsoft.Json;

namespace Course_Poster
{
    class API
    {
        public static string token = "";

        private static string webRequest(string URL)
        {
            WebClient Wc = new WebClient();
            string result = Wc.DownloadString(URL);
            return result;
        }

        private static string webPost(string URL, string METHOD, string DATA = "")
        {
            WebClient Wc = new WebClient();
            Wc.Headers[HttpRequestHeader.ContentType] = "application/x-www-form-urlencoded";
            string result = Wc.UploadString(URL, METHOD, DATA);
            return result;
        }

        public static void setToken(string tkn)
        {
            token = tkn;
        }

        public class Courses
        {
            // API Doc - https://canvas.instructure.com/doc/api/courses.html
            public static dynamic getCourses()
            {
                // Returns an array of courses as JSON.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/courses?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic getCourse(string id, string arg = "")
            {
                // Returns a course object for course with specified ID as JSON.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/courses/" + id + "/" + arg + "/" + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }
        }

        public class Assignments
        {
            // API Doc - https://canvas.instructure.com/doc/api/assignments.html
            public static dynamic get(string id)
            {
                // Returns an array of assignment objects as JSON.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/courses/" + id + "/assignments?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic getSingle(string course_id, string assignment_id)
            {
                // Returns an assignment object as JSON.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/courses/" + course_id + "/assignments/" + assignment_id + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }
        }

        public class Enrollments
        {
            // API Doc - https://canvas.instructure.com/doc/api/enrollments.html
            public static dynamic getEnrollments()
            {
                // Returns an array of enrollments as JSON.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/users/self/enrollments" + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic getSingle(string id)
            {
                // Returns a single enrollment as a JSON object, requires account id.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/users/self/enrollments/" + id + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }
        }

        public class Submissions
        {
            // API Doc - https://canvas.instructure.com/doc/api/submissions.html
            public static dynamic get(string course, string assignment)
            {
                // Returns a JSON array of user submissions for given assignment and course.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/courses/" + course + "/assignments/" + assignment + "/submissions?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }
        }

        public class Users
        {
            // API Doc - https://canvas.instructure.com/doc/api/users.html
            public static dynamic getActivity(bool summary = false)
            {
                // Returns a JSON array of user's activity stream.
                // If given the value true, will return a summary instead of in-depth.
                try
                {
                    string result;
                    if (summary)
                    {
                        result = webRequest("https://canvas.instructure.com/api/v1/users/self/activity_stream/summary" + "?access_token=" + token);
                    }
                    else
                    {
                        result = webRequest("https://canvas.instructure.com/api/v1/users/self/activity_stream" + "?access_token=" + token);
                    }
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic getTodo()
            {
                // Returns a JSON array of user's to-do list.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/users/self/todo" + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic getUpcoming()
            {
                // Returns a JSON array of user's upcoming items.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/users/self/upcoming_events" + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic getMissing()
            {
                // Returns a JSON array of user's missing assignments.
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/users/self/missing_submissions" + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic userInfo(string arg = "")
            {
                // Returns a JSON object of user info.
                // Arg is any object of user such as: settings, colors
                try
                {
                    string result = webRequest("https://canvas.instructure.com/api/v1/users/self" + "/" + arg + "?access_token=" + token);
                    var JSON = JsonConvert.DeserializeObject(result);
                    return JSON;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic nameCourse(string course, string nick)
            {
                // Nickname a course a specific value.
                try
                {
                    string postData = "nickname=" + nick;
                    string result = webPost("https://canvas.instructure.com/api/v1/users/self/course_nicknames/" + course + "?access_token=" + token, "PUT", postData);
                    return result;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }

            public static dynamic unnameCourse(string course)
            {
                // Reset the nickname for a specific course.
                try
                {
                    string result = webPost("https://canvas.instructure.com/api/v1/users/self/course_nicknames/" + course + "?access_token=" + token, "DELETE");
                    return result;
                }
                catch (WebException e)
                {
                    return e.Message.ToString();
                }
            }
        }
    }
}
