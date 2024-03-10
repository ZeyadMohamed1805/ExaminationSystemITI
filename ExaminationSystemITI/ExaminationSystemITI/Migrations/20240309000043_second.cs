using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ExaminationSystemITI.Migrations
{
    /// <inheritdoc />
    public partial class second : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_Email",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_Id",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsID",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_SP",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exams_ExamsID",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseID",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_Email",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersEmail",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestions_Exams_ExamId",
                table: "StudentExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestions_Questions_QuestionId",
                table: "StudentExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestions_Students_StudentId",
                table: "StudentExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Email",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_Email",
                table: "Admins",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_Id",
                table: "Choices",
                column: "Id",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsId",
                table: "CourseDepartment",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsID",
                table: "CourseInstructor",
                column: "InstructorsID",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_SP",
                table: "Departments",
                column: "SP",
                principalTable: "Instructors",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exams_ExamsID",
                table: "ExamQuestion",
                column: "ExamsID",
                principalTable: "Exams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseID",
                table: "Exams",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_Email",
                table: "Instructors",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersEmail",
                table: "RoleUser",
                column: "UsersEmail",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestions_Exams_ExamId",
                table: "StudentExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ID",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestions_Questions_QuestionId",
                table: "StudentExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestions_Students_StudentId",
                table: "StudentExamQuestions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Email",
                table: "Students",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Admins_Users_Email",
                table: "Admins");

            migrationBuilder.DropForeignKey(
                name: "FK_Choices_Questions_Id",
                table: "Choices");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsId",
                table: "CourseDepartment");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsID",
                table: "CourseInstructor");

            migrationBuilder.DropForeignKey(
                name: "FK_Departments_Instructors_SP",
                table: "Departments");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Exams_ExamsID",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion");

            migrationBuilder.DropForeignKey(
                name: "FK_Exams_Courses_CourseID",
                table: "Exams");

            migrationBuilder.DropForeignKey(
                name: "FK_Instructors_Users_Email",
                table: "Instructors");

            migrationBuilder.DropForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_RoleUser_Users_UsersEmail",
                table: "RoleUser");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestions_Exams_ExamId",
                table: "StudentExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestions_Questions_QuestionId",
                table: "StudentExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentExamQuestions_Students_StudentId",
                table: "StudentExamQuestions");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Students_Users_Email",
                table: "Students");

            migrationBuilder.DropForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics");

            migrationBuilder.AddForeignKey(
                name: "FK_Admins_Users_Email",
                table: "Admins",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Choices_Questions_Id",
                table: "Choices",
                column: "Id",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Courses_CoursesId",
                table: "CourseDepartment",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseDepartment_Departments_DepartmentsId",
                table: "CourseDepartment",
                column: "DepartmentsId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Courses_CoursesId",
                table: "CourseInstructor",
                column: "CoursesId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CourseInstructor_Instructors_InstructorsID",
                table: "CourseInstructor",
                column: "InstructorsID",
                principalTable: "Instructors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_Departments_Instructors_SP",
                table: "Departments",
                column: "SP",
                principalTable: "Instructors",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Exams_ExamsID",
                table: "ExamQuestion",
                column: "ExamsID",
                principalTable: "Exams",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_ExamQuestion_Questions_QuestionsId",
                table: "ExamQuestion",
                column: "QuestionsId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Exams_Courses_CourseID",
                table: "Exams",
                column: "CourseID",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Instructors_Users_Email",
                table: "Instructors",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Questions_Courses_CourseId",
                table: "Questions",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Roles_RolesId",
                table: "RoleUser",
                column: "RolesId",
                principalTable: "Roles",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_RoleUser_Users_UsersEmail",
                table: "RoleUser",
                column: "UsersEmail",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Courses_CourseId",
                table: "StudentCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentCourses_Students_StudentId",
                table: "StudentCourses",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestions_Exams_ExamId",
                table: "StudentExamQuestions",
                column: "ExamId",
                principalTable: "Exams",
                principalColumn: "ID");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestions_Questions_QuestionId",
                table: "StudentExamQuestions",
                column: "QuestionId",
                principalTable: "Questions",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentExamQuestions_Students_StudentId",
                table: "StudentExamQuestions",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Departments_DepartmentId",
                table: "Students",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Students_Users_Email",
                table: "Students",
                column: "Email",
                principalTable: "Users",
                principalColumn: "Email");

            migrationBuilder.AddForeignKey(
                name: "FK_Topics_Courses_CourseId",
                table: "Topics",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id");
        }
    }
}
