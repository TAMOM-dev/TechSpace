import Header from "@/features/admin/components/Header";
import Layout from "@/layout/Layout";
import { createFileRoute } from "@tanstack/react-router";
import { useQuery } from "@tanstack/react-query";
import { productsService } from "@/api/services/Products";
import Loading from "@/shared/components/Loading";
import ProductList from "@/features/admin/components/ProductList";
import UpsertProductForm from "@/features/admin/components/UpsertProductForm";
import { useState } from "react";
import type { Product } from "@/type/Product";
import { categoriesRepository } from "@/api/repositories/Categories";

export const Route = createFileRoute("/admin")({
  component: AdminPage,
});

export default function AdminPage() {
  const {
    data: productsData,
    isLoading: isLoadingProducts,
    refetch: refecthProducts,
  } = useQuery({
    queryKey: ["all-products"],
    queryFn: productsService.getAllProducts,
  });

  const { data: categoriesData, isLoading: isLoadingCategories } = useQuery({
    queryKey: ["all-categories"],
    queryFn: categoriesRepository.getAllCategories,
  });

  const [productToUpdate, setProductToUpdate] = useState<Product | undefined>(
    undefined
  );

  const isLoading = [isLoadingProducts, isLoadingCategories].some(Boolean);

  if (isLoading) {
    return <Loading />;
  }

  return (
    <Layout childrenClassName="flex flex-col gap-y-8">
      <Header />
      <UpsertProductForm
        categoriesData={categoriesData ?? []}
        productToUpdate={productToUpdate}
        setProductToUpdate={setProductToUpdate}
        onSubmit={refecthProducts}
      />
      <ProductList
        products={productsData ?? []}
        setProductToUpdate={setProductToUpdate}
        onDelete={refecthProducts}
      />
    </Layout>
  );
}
