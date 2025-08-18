import type { Product } from "@/type/Product";
import ImageFallback from "@/assets/icons/Placeholder.png";

export default function ProductCard({ product }: { product: Product }) {
  const { name, description, price, imageUrl } = product;

  return (
    <article className="w-full h-full flex flex-col gap-y-4">
      <img
        src={imageUrl || ImageFallback}
        alt={name}
        // Add a fallback image if the image fails to load
        onError={(e) => {
          const target = e.currentTarget as HTMLImageElement;
          target.onerror = null;
          target.src = ImageFallback;
        }}
        className="rounded-md aspect-square object-cover"
      />
      <section className="flex flex-col gap-y-2">
        <h2 className="text-xl font-medium">{name}</h2>
        <p className="text-sm text-white/75">{description}</p>
        <p className="text-xl font-bold">${price} USD</p>
      </section>
    </article>
  );
}
