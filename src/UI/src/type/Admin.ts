import type { Product } from "./Product";

export type ProductInputs = {
  name: string;
  description: string;
  imageUrl: string;
  price: number;
  stock: number;
  categoryId: string;
};

export type ProductUpdateInputs = ProductInputs & {
  productId: string;
};

export type AddProduct = {
  success: boolean;
  message: string;
  productDto: Product;
};
