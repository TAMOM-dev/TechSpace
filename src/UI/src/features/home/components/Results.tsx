export default function Results({
  productsLength = 0,
  searchQuery,
}: {
  productsLength: number;
  searchQuery: string;
}) {
  return (
    <section className="flex flex-col gap-y-1">
      <h1 className="text-3xl font-medium">Results</h1>
      <p className="text-white/75">
        {searchQuery.length > 0
          ? `${productsLength} products found for "${searchQuery}"`
          : `${productsLength} products found. Try search bar for more specific results.`}
      </p>
    </section>
  );
}
