# telepathylabs-show-reels

## prerequisites
* Backend dotnet api is built on VS 2022 and dotnet core 6
* Frontend VS Code  and angular 14 with angular cli.
* Postgres db is used for storing data.

## Running the code
* To run frontend run `ng serve` from path `src/TelepathyLabs.ShowReels.Web`. Api Url can be changed by updating `src/assets/config.json`
* To run backend run `dotnet run` from path `src/TelepathyLabs.ShowReels.Api`. Db connection string can be changed by updating `appsettings.json`

## Assumptions
* Consistancy over performance
* No Authentication
* In sample clip data start always zero. but assumed it can be non zero
* Gaps between clips are allowed  


## Next steps
* Integration testing
* Angular unit testing
* Add logging
* Make UI user friendly specially for time code

