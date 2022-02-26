using System.Collections.Generic;

namespace Tank_Game
{
    public interface IHelicopterList
    {
        public List<IHelicopter> helicopters { get; }
        public IHelicopter current { get; set; }
        public void Remove(IHelicopter helicopter);
    }
}
