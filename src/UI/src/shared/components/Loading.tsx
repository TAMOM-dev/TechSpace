import { Loader2 } from "lucide-react";

export default function Loading() {
  return (
    <main className="min-h-screen w-full flex items-center justify-center">
      <Loader2 className="size-10 animate-spin" />
    </main>
  );
}
