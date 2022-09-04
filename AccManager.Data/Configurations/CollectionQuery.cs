using MongoDB.Driver;

namespace AccManager.Data.Configurations
{
    public static class CollectionQuery
    {
        public static (int totalPages, IReadOnlyList<TDocument> data) AggregateByPage<TDocument>(
            this IMongoCollection<TDocument> collection,
            FilterDefinition<TDocument> filterDefinition,
            int page,
            int pageSize)
        {
            var countFacet = AggregateFacet.Create("count",
                PipelineDefinition<TDocument, AggregateCountResult>.Create(new[]
                {
                PipelineStageDefinitionBuilder.Count<TDocument>()
                }));

            var dataFacet = AggregateFacet.Create("data",
                PipelineDefinition<TDocument, TDocument>.Create(new[]
                {
                PipelineStageDefinitionBuilder.Skip<TDocument>((page - 1) * pageSize),
                PipelineStageDefinitionBuilder.Limit<TDocument>(pageSize),
                }));


            var aggregation = collection.Aggregate()
                .Match(filterDefinition)
                .Facet(countFacet, dataFacet)
                .ToList();

            var count = aggregation.First()
                .Facets.First(x => x.Name == "count")
                .Output<AggregateCountResult>()
                ?.FirstOrDefault()
                ?.Count ?? 0;

            var totalPages = (int)Math.Ceiling((double)count / pageSize);

            var data = aggregation.First()
                .Facets.First(x => x.Name == "data")
                .Output<TDocument>();

            return (totalPages, data);
        }
    }
}
