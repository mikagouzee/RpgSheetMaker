export interface Character {
    name: string,
    gameName: string,
    profession: Career,
    baseAttributes: Caracteristic[],
    skills: Caracteristic[],
    stats: Caracteristic[],
    spendablePoints: Caracteristic[]

}

export interface Caracteristic {
    name: string,
    score: number
}


export interface Career {
    name: string,
    jobSkills: Caracteristic[]
}


export interface Game {
    name: string
    ,jobs: string[]
    //,species: string[]
}