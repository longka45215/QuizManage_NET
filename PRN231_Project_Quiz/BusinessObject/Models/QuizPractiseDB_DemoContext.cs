using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BusinessObject.Models
{
    public partial class QuizPractiseDB_DemoContext : DbContext
    {
        public QuizPractiseDB_DemoContext()
        {
        }

        public QuizPractiseDB_DemoContext(DbContextOptions<QuizPractiseDB_DemoContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Answer> Answers { get; set; } = null!;
        public virtual DbSet<Course> Courses { get; set; } = null!;
        public virtual DbSet<CourseCategory> CourseCategories { get; set; } = null!;
        public virtual DbSet<ExpertAssign> ExpertAssigns { get; set; } = null!;
        public virtual DbSet<FavoriteSubject> FavoriteSubjects { get; set; } = null!;
        public virtual DbSet<Question> Questions { get; set; } = null!;
        public virtual DbSet<Quiz> Quizzes { get; set; } = null!;
        public virtual DbSet<QuizHistory> QuizHistories { get; set; } = null!;
        public virtual DbSet<Register> Registers { get; set; } = null!;
        public virtual DbSet<RoleName> RoleNames { get; set; } = null!;
        public virtual DbSet<Subject> Subjects { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server=GACHALIFE\\SQLEXPRESS;database=QuizPractiseDB_Demo;uid=sa;pwd=yolo19528;TrustServerCertificate=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Answer>(entity =>
            {
                entity.ToTable("Answer");

                entity.Property(e => e.AnswerId).HasColumnName("answerID");

                entity.Property(e => e.Content)
                    .HasMaxLength(500)
                    .HasColumnName("content");

                entity.Property(e => e.IsAnswer).HasColumnName("isAnswer");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");

                entity.HasOne(d => d.Question)
                    .WithMany(p => p.Answers)
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Answer_Question");
            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.ToTable("Course");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(2)
                    .HasColumnName("courseID")
                    .IsFixedLength();

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CourseName)
                    .HasMaxLength(50)
                    .HasColumnName("courseName");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Thumbnail)
                    .HasMaxLength(50)
                    .HasColumnName("thumbnail");

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Course_CourseCategory");
            });

            modelBuilder.Entity<CourseCategory>(entity =>
            {
                entity.HasKey(e => e.CategoryId);

                entity.ToTable("CourseCategory");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CategoryName)
                    .HasMaxLength(50)
                    .HasColumnName("categoryName");
            });

            modelBuilder.Entity<ExpertAssign>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ExpertAssign");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(6)
                    .HasColumnName("subjectID")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpertAssign_Subject");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ExpertAssign_User");
            });

            modelBuilder.Entity<FavoriteSubject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("FavoriteSubject");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(6)
                    .HasColumnName("subjectID")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Subject)
                    .WithMany()
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavoriteSubject_Subject");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_FavoriteSubject_User");
            });

            modelBuilder.Entity<Question>(entity =>
            {
                entity.ToTable("Question");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");

                entity.Property(e => e.Content).HasColumnName("content");

                entity.Property(e => e.Explain)
                    .HasMaxLength(500)
                    .HasColumnName("explain");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(6)
                    .HasColumnName("subjectID")
                    .IsFixedLength();

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Questions)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Question_Subject");
            });

            modelBuilder.Entity<Quiz>(entity =>
            {
                entity.ToTable("Quiz");

                entity.Property(e => e.QuizId).HasColumnName("quizID");

                entity.Property(e => e.Score).HasColumnName("score");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(6)
                    .HasColumnName("subjectID")
                    .IsFixedLength();

                entity.Property(e => e.TimeStart)
                    .HasMaxLength(50)
                    .HasColumnName("timeStart");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_Subject");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Quizzes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Quiz_User");
            });

            modelBuilder.Entity<QuizHistory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("QuizHistory");

                entity.Property(e => e.IsCorrect).HasColumnName("isCorrect");

                entity.Property(e => e.QuestionId).HasColumnName("questionID");

                entity.Property(e => e.QuizId).HasColumnName("quizID");

                entity.Property(e => e.UserAnswer).HasColumnName("userAnswer");

                entity.HasOne(d => d.Question)
                    .WithMany()
                    .HasForeignKey(d => d.QuestionId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuizHistory_Question");

                entity.HasOne(d => d.Quiz)
                    .WithMany()
                    .HasForeignKey(d => d.QuizId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QuizHistory_Quiz");
            });

            modelBuilder.Entity<Register>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Register");

                entity.Property(e => e.CourseId)
                    .HasMaxLength(2)
                    .HasColumnName("courseID")
                    .IsFixedLength();

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.HasOne(d => d.Course)
                    .WithMany()
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Activity_Course");

                entity.HasOne(d => d.User)
                    .WithMany()
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Register_User");
            });

            modelBuilder.Entity<RoleName>(entity =>
            {
                entity.HasKey(e => e.RoleId);

                entity.ToTable("RoleName");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedNever()
                    .HasColumnName("roleID");

                entity.Property(e => e.RoleName1)
                    .HasMaxLength(50)
                    .HasColumnName("roleName");
            });

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.ToTable("Subject");

                entity.Property(e => e.SubjectId)
                    .HasMaxLength(6)
                    .HasColumnName("subjectID")
                    .IsFixedLength();

                entity.Property(e => e.CourseId)
                    .HasMaxLength(2)
                    .HasColumnName("courseID")
                    .IsFixedLength();

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.SubjectName)
                    .HasMaxLength(80)
                    .HasColumnName("subjectName");

                entity.HasOne(d => d.Course)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.CourseId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subject_Course");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("User");

                entity.Property(e => e.UserId).HasColumnName("userID");

                entity.Property(e => e.Avatar)
                    .HasMaxLength(50)
                    .HasColumnName("avatar");

                entity.Property(e => e.Description)
                    .HasMaxLength(500)
                    .HasColumnName("description");

                entity.Property(e => e.Email)
                    .HasMaxLength(50)
                    .HasColumnName("email");

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .HasColumnName("fullName");

                entity.Property(e => e.Password)
                    .HasMaxLength(200)
                    .HasColumnName("password");

                entity.Property(e => e.RegisterDay)
                    .HasColumnType("date")
                    .HasColumnName("registerDay");

                entity.Property(e => e.RoleId).HasColumnName("roleID");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.UserName)
                    .HasMaxLength(50)
                    .HasColumnName("userName");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Users)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_RoleName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
