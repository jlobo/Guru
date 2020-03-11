import superagent from 'superagent';
import Member from "./Member";

export default class GuruClient {
    /** @param {string} url */
    constructor(url) {
        this.url = url;
    }

    /**
     * @param {any} id
     * @returns {Promise<Member>}
     */
    async getById(id) {
        return Member.from((await superagent.get(`${this.url}/member/${id}`)).body);
    }

    /**
     * @returns {Promise<Member[]>}
     */
    async getAll() {
        return (await superagent.get(`${this.url}/member`)).body.map(itm => Member.from(itm));
    }

    /**
     * @param {Member} member
     */
    async addOrUpdate(member) {
        await superagent.post(`${this.url}/member`).send(JSON.stringify(member)).set('Content-Type', 'application/json');
    }

    /** @param {number} id */
    async delete(id) {
        await superagent.delete(`${this.url}/member/${id}`);
    }
}

