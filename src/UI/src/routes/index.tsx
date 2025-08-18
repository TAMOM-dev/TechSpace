import Layout from "@/layout/Layout";
import { productsService } from "@/api/services/Products";
import { useQuery } from "@tanstack/react-query";
import Results from "@/features/home/components/Results";
import ProductCard from "@/features/products/components/ProductCard";
import Loading from "@/shared/components/Loading";
import { useState } from "react";
import { searchProducts } from "@/features/products/utils/search";
import { Coffee } from "lucide-react";
import { createFileRoute } from "@tanstack/react-router";

export const Route = createFileRoute("/")({
  component: HomePage,
});

export default function HomePage() {
  const [searchQuery, setSearchQuery] = useState<string>("");

  const { data: productsData, isLoading: isLoadingProducts } = useQuery({
    queryKey: ["all-products"],
    queryFn: productsService.getAllProducts,
  });

  const products = searchProducts(productsData ?? [], searchQuery);

  const productsLength = products?.length ?? 0;

  if (isLoadingProducts) {
    return <Loading />;
  }

  return (
    <Layout
      childrenClassName="flex flex-col gap-y-5"
      searchQuery={searchQuery}
      setSearchQuery={setSearchQuery}
    >
      <Results productsLength={productsLength} searchQuery={searchQuery} />
      {products.length === 0 ? (
        <section className="flex flex-col gap-y-5 flex-1 items-center justify-center">
          <p className="text-lg text-white/75 italic">
            {searchQuery.length > 0
              ? `No results found for ${searchQuery}`
              : "No results found"}
          </p>
          <Coffee className="size-7 text-white/75" strokeWidth={1.4} />
        </section>
      ) : (
        <section className="grid grid-cols-[repeat(auto-fill,minmax(140px,1fr))] md:grid-cols-[repeat(auto-fill,minmax(200px,1fr))] gap-8">
          {products.map((product) => (
            <ProductCard key={product.productId} product={product} />
          ))}
        </section>
      )}
    </Layout>
  );
}
