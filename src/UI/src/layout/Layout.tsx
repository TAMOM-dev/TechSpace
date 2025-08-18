import { cn } from "@/shared/utils/cn";
import Footer from "./Footer";
import Navbar from "./Navbar";

export default function Layout({
  children,
  className,
  childrenClassName,
  searchQuery,
  setSearchQuery,
}: {
  children: React.ReactNode;
  className?: string;
  childrenClassName?: string;
  searchQuery?: string;
  setSearchQuery?: React.Dispatch<React.SetStateAction<string>>;
}) {
  return (
    <main
      className={cn(
        "flex flex-col justify-between min-h-screen width-container",
        className
      )}
    >
      <Navbar searchQuery={searchQuery} setSearchQuery={setSearchQuery} />
      <div className={cn("flex-1 p-10", childrenClassName)}>{children}</div>
      <Footer />
    </main>
  );
}
