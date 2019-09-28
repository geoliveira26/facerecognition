using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Emgu.CV.Face.FaceRecognizer;

namespace facerecognition.Models
{
    public class Recognition
    {
        public User User { get; set; }

        public PredictionResult Prediction { get; set; }
    }
}
