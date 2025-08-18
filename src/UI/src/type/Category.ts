import type { Product } from "./Product";

export type Category = {
  categoryId: number;
  name: string;
  products: Product[];
};
