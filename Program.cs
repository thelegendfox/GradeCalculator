// ~~The initializing namespace for the project. This one's called "cs_learning" because...~~
// ~~well, I'm learning C#.~~

// ~~Also, the IDE yells at me if I call it anything else. That's a big factor.~~

// (I changed the filename.)
namespace GradeCalculator
{

    // This uses a primary constructor (that's the thing after "struct Course")
    // instead of a "normal" one (i.e. "public Course(string name) {... Name = name;}"). 
    // Now, I don't know if that's better, per se, but it's what VSCode recommends.
    public readonly struct Course(string name, int credit, string grade)
    {
        // Public, for something that can be accessed outside of the class.
        public string Name { get; } = name;
        // int, for the type (same with "string").
        public int Credit { get; } = credit;
        // and "get" means that you can pull this. Otherwise it has to be readonly.
        public string Grade { get; } = grade;
        // it probably should be readonly anyways...
    }

    // The same thing here, except I use an array of Courses.
    public readonly struct Student(string name, Course[] courses)
    {
        public string Name { get; } = name;
        public Course[] Courses { get; } = courses;
    }

    // The first initializing thingie.
    // I don't actually know what to call this? But I think "application" is fine.
    public class Application
    {
        // And static void main, the entry point.
        // Don't get zapped.
        static void Main()
        {
            // Initializing a new student, "sophia".
            // "new" makes a new one of the type (i.e. string aeiou = new("aeiou");).
            Student sophia = new(
                // The name.
                "Sophia X.",
                // Then, an array.
                [   // Making new Courses.
                    new("English 101", 3, "A"),
                    new("Algebra 101", 3, "B"),
                    new("Biology 101", 4, "B"),
                    new("Computer Science I", 4, "B"),
                    new("Psychology 101", 3, "A")
                ]
            );

            // A simple function to extract the credit hours from a bunch of courses.
            // Now, I don't know if this is "placed" correctly. Maybe I'm supposed to 
            // put it in Application, or another file, or... something else.
            // Anyways, this could also be static. But it isn't. I didn't add that.
            int GetTotalCreditHours(Course[] courses)
            {
                // Initializing this value as 0 in case there are no courses.
                int totalCreditHours = 0;

                // Basic of basic for loops. You'll see when I learned foreach.
                for (int i = 0; i < courses.Length; i++)
                {
                    totalCreditHours += courses[i].Credit;
                }

                return totalCreditHours;
            }

            // All the same as GetTotalCreditHours.
            // I could probably make both of these into one function returning a record,
            // but I didn't.
            int GetTotalGradePoints(int creditHours, Course[] courses)
            {
                int totalGradePoints = 0;

                // And here's the foreach. Turns out knowing a different programming lang
                // makes learning a new lang a piece of cake!
                foreach (Course course in courses)
                {
                    // This was added in after I realized that I can't just grab an array
                    // of grades. (They're all in courses.) So real quick I just popped
                    // these few lines in.
                    int gradeNum;
                    if (course.Grade is "A" or "a") { gradeNum = 4; }
                    else if (course.Grade is "B" or "b") { gradeNum = 3; }
                    else gradeNum = 0; // silently fail until further notice
                    // (I don't care to add C D and F and whatever sorry)

                    // Grade Points is creditHours * the grade. Each grade letter corresponds
                    // to a specific number, as seen above.
                    totalGradePoints += creditHours * gradeNum;
                }

                return totalGradePoints;
            }

            // I decided to make this a function because I feel like having a foreach
            // in the "busy part" of your code sucks.
            void DisplayCourseInfo(Course[] courses)
            {
                foreach (Course course in courses)
                {
                    // ToUpper for the fancy factor. Also, to use built in methods.
                    Console.WriteLine($"{course.Name.ToUpper()}:");
                    // And just an indent because why not.
                    Console.WriteLine($"     Grade: {course.Grade}");
                    Console.WriteLine($"     Credit: {course.Credit}");
                }
            }

            // Assigning these for use a few nanoseconds into the future.
            int totalCreditHours = GetTotalCreditHours(sophia.Courses);
            int totalGradePoints = GetTotalGradePoints(totalCreditHours, sophia.Courses);

            // And the only part you actually see: fun!
            Console.WriteLine($"|-----------COURSES AND GPA-----------|");
            Console.Write("\n");
            DisplayCourseInfo(sophia.Courses);
            Console.Write("\n");
            Console.WriteLine($"TOTAL CREDIT HOURS: {totalCreditHours}");
            Console.WriteLine($"TOTAL GRADE POINTS: {totalGradePoints}");
            Console.WriteLine($"|-----------------ENDS----------------|");
            // Fun fact, "ENDS" is actually off center. Now you can't unsee it. You're welcome.

            /* 
            BASED ON: https://learn.microsoft.com/en-us/training/modules/guided-project-calculate-final-gpa/4-exercise-calculate-sum

            Had a bit of fun building this. Learned some stuff.
            Decided to make it because I looked at the above link and decided "pssh, 
            they're repeating all that code for no reason! I'm sure I can make it WAY
            better." Lo and behold, I *did* make it better, and far more complicated!

            Instead of spending 5-10 minutes just writing the dang stuff... I spent
            about an hour, I think? On this. But now if I ever want to make more, I can
            ...well, still manually edit the code. But now I have a cooler looking one.
            And instead of repeating code, I just added triple the lines! Yaaay!

            But anyways. I think a bit of overcomplication is worth the trouble.

            I think over half the lines of this thing are comments, anyways.

            */

        }
    }
}

// Storing old stuff here because why not
/*
for (int i = 0; i < grades.Length; i++)
                {
                    switch (grades[i])
                    {
                        case "A" or "a":
                            totalCreditHours += 4;
                            break;
                        case "B" or "b":
                            totalCreditHours += 3;
                            break;
                        default:
                            break;
                    }
                }
                */