# SolWatch
## Astrodynamics
Currently, a few simplifications have been made to the astrodynamic model to speed development. In the future we may upate the model to be slightly more accurate.
### Eccentricity
Because all planets of the Sol System have eccentricities near 0, we've approximated their orbits to be circular. Furtermore, mean anomaly and true anomaly are considered equivalent.
### Inclination
Because all planets of the Sol System have inclinations near 0, and our display is 2 dimensional we've approxmated their orbits to be on the ecliptic plane. This is essentially a projection of their orbital plane onto the ecliptic plane.