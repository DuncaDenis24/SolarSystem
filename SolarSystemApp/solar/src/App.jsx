import React, { useEffect, useState } from "react";
import PlanetsList from "./PlanetsList";
import "./App.css";

const App = () => {
    const [planets, setPlanets] = useState([]);
    const [loading, setLoading] = useState(true);
    const [error, setError] = useState(null);

    useEffect(() => {
        fetch("http://localhost:5000/api/planets") // Schimbă URL-ul cu cel corect
            .then((response) => {
                if (!response.ok) {
                    throw new Error("Eroare la preluarea datelor");
                }
                return response.json();
            })
            .then((data) => {
                setPlanets(data);
                setLoading(false);
            })
            .catch((error) => {
                setError(error.message);
                setLoading(false);
            });
    }, []);

    return (
        <div className="app-container">
            <h1>Lista Planetelor</h1>
            {loading && <p>Se încarcă...</p>}
            {error && <p className="error">{error}</p>}
            {!loading && !error && <PlanetsList planets={planets} />}
        </div>
    );
};

export default App;
