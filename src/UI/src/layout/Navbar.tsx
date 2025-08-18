import Logo from "@/assets/icons/logo.png";
import { Link } from "@tanstack/react-router";

export default function Navbar({
  searchQuery,
  setSearchQuery,
}: {
  searchQuery?: string;
  setSearchQuery?: (value: string) => void;
}) {
  return (
    <header className="w-full p-8 flex items-center justify-between gap-x-64 bg-gradient-to-b from-zinc-900/0">
      {/* Logo */}
      <Link to="/" className="[&.active]:font-bold">
        <img src={Logo} className="size-14" />
      </Link>

      {/* Search */}
      <div className="flex w-full max-w-2xl">
        <input
          type="text"
          placeholder="Search..."
          className="border border-zinc-700 p-3 w-full rounded-md"
          value={searchQuery}
          onChange={(e) => {
            if (setSearchQuery) {
              setSearchQuery(e.target.value);
            }
          }}
        />
      </div>

      {/* Slogan */}
      <Link
        to="/admin"
        className="bg-primary hover:bg-primary/85 transition-colors duration-300 py-3 px-6 rounded-md cursor-pointer"
      >
        Admin Panel
      </Link>
    </header>
  );
}
