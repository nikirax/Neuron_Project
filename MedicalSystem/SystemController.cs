using NeuronProject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalSystem
{
    public class SystemController
    {
        public NeuronNetwork DataNetwork { get; }
        public NeuronNetwork ImageNetwork { get; }

        public SystemController()
        {
            var dataTopology = new Topology(14, 1, 0.1, 7);
            DataNetwork = new NeuronNetwork(dataTopology);

            var imageTopology = new Topology(400, 1, 0.1, 200);
            ImageNetwork = new NeuronNetwork(imageTopology);
        }
    }
}
