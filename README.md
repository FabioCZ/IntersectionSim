Welcome to the project page for Intersection Simulator (aka Merry-Go-Round-About)

![Merry-go-round](http://fabiocz.github.io/images/merryGo.jpg)


## Project Introduction:

As connected autonomous vehicles will become more and more common in the coming decades, this technology can be used to reduce traffic congestion, a big problem in major metropolitan areas.  Cars will be able to communicate with each other, as well as communicate with a central traffic management system. One interesting part of traffic control that can be evaluated is the use of roundabouts.

## Why:
Roundabouts are an efficient alternative to traditional 4-way stops. However, they can suffer from starvation under heavy traffic flow. Additionally, human drivers do not always most efficiently utilize the gaps in traffic available to them, and increase congestion. This gap-management could be made more efficient using connected autonomous vehicles. This can reduce fuel costs and travel time, as well reduce carbon footprint from fossil fuel vehicles.


![Diagram](http://fabiocz.github.io/images/roundaboutdiagram.PNG)

## Implementation:
The roundabout can be thought of as a merry-go-round with 'slots' for each car that is on the roundabout. Roundabout entry points are where pop in a car into a slot. We can then 'spin' the merry-go-round until the desired leave point is reached, where we pop the car out of the slot. To find optimal configurations under heavy traffic and prevent car starvation, an intelligent algorithm is used. Starvation refers to some cars having to wait a lot longer to pass through the roundabout than other cars (see link at the bottom for more information).

The efficiency of the algorithm is measured by the average and maximum wait time of all the cars on the roundabout at the time of decision making. A reference conventional roundabout is implemented as a control. The intelligent roundabout is implemented using a minimax algorithm. At each iteration of the roundabout state, all of the next possible steps are evaluated and the best one (lowest average wait time) is selected as the next step. Pseudocode for the MiniMax algorithm can be found below.



    // from https://en.wikipedia.org/wiki/Minimax
    function minimax(node, depth, maximizingPlayer)
        if depth = 0 or node is a terminal node
            return the heuristic value of node
        for each child of node
        val := minimax(child, depth - 1, !maximizingPlayer)
            bestValue := -∞
            bestValue := min(bestValue, val)
    return bestValue


##Video Demo:
[![IMAGE ALT TEXT](http://img.youtube.com/vi/uild35AoGqg/0.jpg)](http://www.youtube.com/watch?v=uild35AoGqg "Video Title")


## Results:
The implemented Minimax algorith does very well at avoiding car starvation and prioritizing cars that have been waiting for some time. The graph below shows the difference between a conventional and intelligent roundabout. For a short simulation duration, cars do not stack up, and both implementions fare similarly. However, with longer simulation durations, cars stack up (especially with higher cars/minute ratios), and the intelligent algorithm outperforms the conventional one significantly.

*Result Graph  and its corresponding table (all values in seconds)*

![Diagram](http://fabiocz.github.io/images/graph.png)

![Table](http://fabiocz.github.io/images/table.png)


## User Interface Description:
The user can choose the input parameters for each lane coming into the roundabout - traffic density (cars per minute) as well as the distribution of destination lanes. The duration of the simulation as well as the speed-up of the simulation can also be altered. At any point, the user can run the animation continuously, or choose to iterate second-by-second to facilitate easier inspection. A conventional roundabout implementation is provided for reference. Also, to aid generating bulk data, user can choose to generate several runs of the simulation with random parameters (min/max for each parameter can be set). This data set generator can write results to a file for further analysis.

![UI](http://fabiocz.github.io/images/ui.PNG)


## Technologies Used:
Project is implemented in C# and will include a WinForms based visualization and controls. .NET data structures are used to store state data (`Queue<T>`, `List<T>` etc.).

## Download

Windows installer:
[https://github.com/FabioCZ/IntersectionSim/releases](https://github.com/FabioCZ/IntersectionSim/releases)

## Links:
* Source code: [https://github.com/FabioCZ/IntersectionSim](https://github.com/FabioCZ/IntersectionSim)
* Minimax: [https://en.wikipedia.org/wiki/Minimax](https://en.wikipedia.org/wiki/Minimax)
* Starvation: [https://en.wikipedia.org/wiki/Starvation_(computer_science)](https://en.wikipedia.org/wiki/Starvation_(computer_science))
* Images from: [http://wikipedia.org](http://wikipedia.org)
