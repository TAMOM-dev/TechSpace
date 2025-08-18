import type { Product } from "@/type/Product";

export function searchProducts(products: Product[], searchQuery: string) {
  return products.filter((product) => {
    return product.name.toLowerCase().includes(searchQuery.toLowerCase());
  });
}
