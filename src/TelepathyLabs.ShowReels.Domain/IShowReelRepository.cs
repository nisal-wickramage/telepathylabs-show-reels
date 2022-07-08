namespace TelepathyLabs.ShowReels.Domain
{
    public interface IShowReelRepository
    {
        ShowReel Create(ShowReel showReel);
        IEnumerable<ShowReel> Get();
    }
}

