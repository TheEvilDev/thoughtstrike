using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Ideastrike.Models
{
    public sealed class Idea
    {
        public Idea()
        {
            Activities = new Collection<Activity>();
            Votes = new Collection<Vote>();
            Features = new Collection<Feature>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public DateTime Time { get; set; }

        public ICollection<Vote> Votes { get; set; }

        public ICollection<Activity> Activities { get; set; }
        public ICollection<Feature> Features { get; set; }

        public User Author { get; set; }

        [NotMapped]
        public bool UserHasVoted { get; set; }
		
        public ICollection<Image> Images { get; set; }

        public string GithubUrl { get; set; }
        public string GithubName { get; set; }
    }
}