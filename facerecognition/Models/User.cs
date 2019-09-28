using Emgu.CV;
using Emgu.CV.Structure;

namespace facerecognition.Models
{
    public class User
    {
        public int Id { get; set; } = RecognitionSingleton.Users.Count + 1;

        public string Name { get; set; }

        public Image<Gray, byte> Face { get; set; }

        public User(Image<Gray, byte> face)
        {
            Face = face;
        }

        public User(string name, Image<Gray, byte> face) : this(face)
        {
            Name = name;
        }

        public User(int id, string name, Image<Gray, byte> face = null) : this(name, face)
        {
            Id = id;
        }
    }
}