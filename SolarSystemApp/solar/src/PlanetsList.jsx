import React from "react";
import "./App.css";

const PlanetsList = ({ planets }) => {
    return (
        <ul className="planets-list">
            {planets.map((planet) => (
                <li key={planet.id} className="planet-item">
                    {planet.name} - {planet.description}
                </li>
            ))}
        </ul>
    );
};

export default PlanetsList;