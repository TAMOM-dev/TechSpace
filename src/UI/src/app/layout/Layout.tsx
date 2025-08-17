import Footer from "./Footer";
import Navbar from "./Navbar";

export default function Layout() {
    return (
    <main className="flex flex-col justify-between min-h-screen px-4 py-12 sm:px-6 lg:px-8">
        <Navbar />
        <Footer />
    </main>
    )
}