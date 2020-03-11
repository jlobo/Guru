import assert from 'assert';
import GuruClient from '../src/GuruClient';
process.env['NODE_TLS_REJECT_UNAUTHORIZED'] = "0";

describe('GuruClient', function () {
    it('should get add update delte', async function () {
        var client = new GuruClient("https://localhost:5001");
        var before = await client.getAll();
    
        
        var toAdd = before[0].clone();
        toAdd.id = randomId();
        toAdd.email = toAdd.id + '@tmp.com';
    
        await client.addOrUpdate(toAdd);
        var added = await client.getById(toAdd.id);
        assert.equal(added.email, toAdd.email);
    
    
        var toUpdate = added;
        toUpdate.email = "personal@gmail.com";
        await client.addOrUpdate(toUpdate);
    
        var updated = await client.getById(toUpdate.id);
        assert.equal(updated.email, toUpdate.email);
    
        await client.delete(updated.id);
    
        var after = await client.getAll();
        
        assert.equal(before.length, after.length);
        for (let i = 0; i < before.length; i++) {
            assert.equal(before[i].id, after[i].id);
        }
    });
});

function randomId() {
    return Math.floor((Math.random() * 20) + 100);
}