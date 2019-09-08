using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.Structure;
using System.Collections.Generic;
using System.Linq;

namespace facerecognition.Models
{
    public class User
    {
        public int Id { get; set; }

        public List<Image<Gray, byte>> Photos { get; set; } = new List<Image<Gray, byte>>();

        public User(int id, List<Image<Gray, byte>> photos)
        {
            Id = id;
            Photos = photos;
        }

        public User(int id, Image<Gray, byte> photo) : this(id, new List<Image<Gray, byte>> { photo })
        {
        }
    }
}