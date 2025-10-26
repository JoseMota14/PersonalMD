# PersonalMD

## Tests

### Coverage

dotnet test --collect:"XPlat Code Coverage"
reportgenerator -reports:"coverage.cobertura.xml" -targetdir:"coveragereport" -reporttypes:Html

Coverage Gutters extension
