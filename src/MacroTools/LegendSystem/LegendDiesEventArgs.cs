using System;
using static War3Api.Common;
namespace MacroTools.LegendSystem
{
  /// <summary>
  /// Event arguments for when a <see cref="Legend"/> dies.
  /// </summary>
  public class LegendDiesEventArgs : EventArgs
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="LegendDiesEventArgs"/> class.
    /// </summary>
    public LegendDiesEventArgs(Legend killedLegend, player killingPlayer)
    {
      KilledLegend = killedLegend;
      KillingPlayer = killingPlayer;
    }

    /// <summary>
    ///The unit killed
    /// </summary>
    public Legend KilledLegend { get; set; }

    /// <summary>
    ///The player killing the unit
    /// </summary>
    public player KillingPlayer { get; set; }

  }
}
