using System;
using _03.CompanyHierarchy.Interfaces;

namespace _03.CompanyHierarchy
{
    class Project : IProject
    {
        private string projectName;

        public Project(string projectName, DateTime projectStartDate, ProjectState projectState, string details)
        {
            this.ProjectName = projectName;
            this.ProjectStartDate = projectStartDate;
            this.ProjectState = projectState;
            this.Details = details;
        }

        public Project(string projectName, string details = null)
                    : this(projectName, DateTime.Now, ProjectState.Open, details)
        {
        }
        public string ProjectName
        {
            get
            {
                return this.projectName;
            }

            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("projectName", "Project name cannot be empty.");
                }

                this.projectName = value;
            }
        }

        public DateTime ProjectStartDate { get; set; }

        public string Details { get; set; }

        public ProjectState ProjectState { get; protected set; }

        public void CloseProject()
        {
            this.ProjectState = ProjectState.Closed;
        }

        public override string ToString()
        {
            return string.Format(
                $"Project: {this.ProjectName} " +
                $"(started: {this.Details}, " +
                $"status: {this.ProjectState}) - {this.Details}");
        }
    }
}