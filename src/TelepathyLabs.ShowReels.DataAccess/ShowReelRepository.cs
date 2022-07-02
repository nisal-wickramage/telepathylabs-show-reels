using TelepathyLabs.ShowReels.Domain;

namespace TelepathyLabs.ShowReels.DataAccess
{
    public class ShowReelRepository: IShowReelRepository
    {
        private readonly TelepathyLabsDbContext _dbContext;

        public ShowReelRepository(TelepathyLabsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public ShowReel Create(ShowReel showReel)
        {
            _dbContext.Database.EnsureCreated();

            var showReelDbModel = new ShowReelDbModel();
            showReelDbModel.Name = showReel.Name;
            showReelDbModel.Description = showReel.Description;
            showReelDbModel.VideoDefinition = showReel.VideoDefinition;
            showReelDbModel.VideoStandard = showReel.VideoStandard;
            showReelDbModel.VideoClips = showReel.VideoClips;

            _dbContext.ShowReels.Add(showReelDbModel);
            _dbContext.SaveChanges();
            return showReel;
        }

        public IEnumerable<ShowReel> Get()
        {
            var showReels = _dbContext.ShowReels
                .Where(s => s.Id > 0)
                .Select(s => new ShowReel(
                        s.Name,
                        s.Description,
                        s.VideoStandard,
                        s.VideoDefinition,
                        s.VideoClips
                    )).ToList();

            return showReels;
        }
    }
}

