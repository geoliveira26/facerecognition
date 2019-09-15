using Emgu.CV;
using Emgu.CV.Structure;
using System.Collections.Generic;

namespace facerecognition.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<Image<Gray, byte>> Photos { get; set; } = new List<Image<Gray, byte>>();

        public User(List<Image<Gray, byte>> photos)
        {
            Photos = photos ?? new List<Image<Gray, byte>>();
        }

        public User(string name, List<Image<Gray, byte>> photos) : this(photos)
        {
            Name = name;
        }

        public User(int id, string name, List<Image<Gray, byte>> photos = null) : this(name, photos)
        {
            Id = id;
        }
    }
}