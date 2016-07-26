#region

using PokemonGo.RocketAPI.Enums;
using System.Collections.Generic;

#endregion

namespace PokemonGo.RocketAPI
{
    public interface ISettings
    {
        AuthType AuthType { get; }
        string Location { get; set; }
        double DefaultLatitude { get; set; }
        double DefaultLongitude { get; set; }
        string LevelOutput { get; }
        int LevelTimeInterval { get; }
        string GoogleRefreshToken { get; set; }
        string PtcPassword { get; }
        string PtcUsername { get; }
        bool EvolveAllGivenPokemons { get; }
        string TransferType { get; }
        int TransferCPThreshold { get; }
        bool Recycler { get; }
        ICollection<KeyValuePair<AllEnum.ItemId, int>> ItemRecycleFilter { get; }
        int RecycleItemsInterval { get; }
        string Language { get; }
        string RazzBerryMode { get; }
        double RazzBerrySetting { get; }
        bool CatchOnlySpecific { get; }
        bool EggHatchedOutput { get; }
        string UseLuckyEggMode { get; }
    }
}
