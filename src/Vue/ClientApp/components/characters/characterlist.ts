import Vue from 'vue';
import { Component } from 'vue-property-decorator';

@Component
export default class CharacterListComponent extends Vue{
    characters: Character[] = [];

    mounted() {
        fetch('http://localhost:53713/api/FalloutCharacter/')
            .then(response => response.json() as Promise<Character[]>)
            .then( data => {
                this.characters = data;
            });

        console.log(this.characters);
    }

}


interface Character {
    Name : string, 
    Profession: Career,
    baseAttributes: Caracteristic[],
    skills: Caracteristic[],
    stats: Caracteristic[],
    spendablePoints: Caracteristic[]
    
}

interface Caracteristic{
    Name: string,
    Score: number
}


interface Career{
    Name:string,
    JobSkills:Caracteristic[]
}